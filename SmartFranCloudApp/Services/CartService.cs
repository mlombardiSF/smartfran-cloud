// Singleton inyectable — el carrito vive aquí y es compartido por
// VentaMinorista (panel de ventas) y el modal de pago (siguiente etapa).

using SmartFranCloudApp.Models;

namespace SmartFranCloudApp.Services;

public class CartService {
	private readonly List<CartItemModel> _items = new();

	// Evento que dispara re-render en cualquier componente suscripto
	public event Action? OnCartChanged;

	// ── Lectura ───────────────────────────────────────────────────────────
	public IReadOnlyList<CartItemModel> Items => _items.AsReadOnly();
	public int    TotalItems    => _items.Sum(i => i.Quantity);
	public decimal Subtotal     => _items.Sum(i => i.Total);

	// Socio activo (compartido con modal de pago)
	public SocioModel? SocioActive { get; private set; }

	public bool    HasRedemptions        => _items.Any(i => i.IsRedemption);
	public int     CommittedPoints       => _items.Where(i => i.IsRedemption).Sum(i => i.RedemptionPoints * i.Quantity);
	public int     TotalRedemptionPoints => CommittedPoints;
	public int     AvailablePoints       => SocioActive is not null ? SocioActive.Points - CommittedPoints : 0;

	// El descuento por nivel no aplica cuando hay canjes en el carrito
	public decimal DiscountSocio =>
		SocioActive is not null && !HasRedemptions ? SocioActive.Discount / 100m : 0m;

	public decimal AmountDiscount   => Subtotal * DiscountSocio;
	public decimal AmountRedemption => _items.Where(i => i.IsRedemption).Sum(i => i.Total);
	public decimal Total            => Subtotal - AmountDiscount;

	// ── Carrito ───────────────────────────────────────────────────────────
	public void AddProduct(Product p) {
		var existing = _items.FirstOrDefault(i => i.Id == p.Id && !i.IsRedemption);

		if (existing is not null){
			existing.Quantity++;
		}else {
			_items.Add(new CartItemModel
			{
				Id       = p.Id,
				Name     = p.Name,
				Price    = p.Price,
				ImageUrl = p.ImageUrl,
				Quantity = 1,
			});
		}

		Notify();
	}

	public void AddRedemption(RedemptionModel c) {
		var id = $"canje-{c.Name}";
		var existing = _items.FirstOrDefault(i => i.Id == id);
		
		if (existing is not null) {
			existing.Quantity++;
		}else {
			_items.Add(new CartItemModel
			{
				Id         = id,
				Name     = c.Name,
				Price    = c.Money,
				IsRedemption = true,
				RedemptionPoints= c.Points,
				Quantity   = 1,
			});
		}

		Notify();
	}

	public void AddItem(string id) {
		var item = _items.FirstOrDefault(i => i.Id == id);
		if (item is not null) { item.Quantity++; Notify(); }
	}

	public void DecreaseItem(string id)	{
		var item = _items.FirstOrDefault(i => i.Id == id);
		if (item is null) return;
		if (item.Quantity <= 1) ClearItem(id);
		else { item.Quantity--; Notify(); }
	}

	public void ClearItem(string id) {
		var item = _items.FirstOrDefault(i => i.Id == id);
		if (item is not null) { _items.Remove(item); Notify(); }
	}

	public void EmptyCart() {
		_items.Clear();
		Notify();
	}

	// ── Socio ─────────────────────────────────────────────────────────────
	public void SetSocio(SocioModel? socio) {
		SocioActive = socio;
		Notify();
	}

	public void ClearRedemptions() {
		_items.RemoveAll(i => i.IsRedemption);
		Notify();
	}

	public void ClearSocio() {
		ClearRedemptions();
		SetSocio(null);
	}

	// ── Notificación ──────────────────────────────────────────────────────
	private void Notify() => OnCartChanged?.Invoke();
}
