using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.InterviewPractice.Meijer_SSE_Pos
{
    public class PosService
    {
        private readonly decimal _taxRate;

        public PosService(decimal taxRate)
        {
            if (taxRate < 0)
                throw new ArgumentException("Tax rate cannot be negative.");

            _taxRate = taxRate;
        }

        public Receipt Checkout(Cart cart, Payment payment)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            if (payment == null)
                throw new ArgumentNullException(nameof(payment));

            if (cart.IsEmpty())
                throw new InvalidOperationException("Cart is empty.");

            var subtotal = cart.GetSubtotal();
            var tax = cart.GetTax(_taxRate);
            var total = cart.GetTotal(_taxRate);

            if (!payment.IsSufficient(total))
                throw new InvalidOperationException("Payment is insufficient.");

            var receiptLines = cart.Items
                .Select(x => new ReceiptLine(
                    x.Item.Name,
                    x.Quantity,
                    x.Item.Price,
                    x.GetLineTotal()))
                .ToList();

            var receipt = new Receipt(
                receiptLines,
                subtotal,
                tax,
                total,
                payment.AmountPaid,
                payment.GetChange(total));

            cart.Clear();

            return receipt;
        }
    }

    public enum PaymentMethod
    {
        Cash,
        CreditCard,
        DebitCard,
        MobileWallet
    }

    public class Item
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Item(int id, string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Item name cannot be empty.");

            if (price < 0)
                throw new ArgumentException("Price cannot be negative.");

            Id = id;
            Name = name;
            Price = price;
        }
    }

    public class CartItem
    {
        public Item Item { get; }
        public int Quantity { get; private set; }

        public CartItem(Item item, int quantity)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            Quantity += quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            Quantity = quantity;
        }

        public decimal GetLineTotal()
        {
            return Item.Price * Quantity;
        }
    }

    public class Cart
    {
        private readonly List<CartItem> _items = new();

        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        public void AddItem(Item item, int quantity = 1)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");

            var existingCartItem = _items.FirstOrDefault(x => x.Item.Id == item.Id);

            if (existingCartItem != null)
            {
                existingCartItem.IncreaseQuantity(quantity);
            }
            else
            {
                _items.Add(new CartItem(item, quantity));
            }
        }

        public void RemoveItem(int itemId)
        {
            var cartItem = _items.FirstOrDefault(x => x.Item.Id == itemId);
            if (cartItem != null)
            {
                _items.Remove(cartItem);
            }
        }

        public void UpdateItemQuantity(int itemId, int quantity)
        {
            var cartItem = _items.FirstOrDefault(x => x.Item.Id == itemId);

            if (cartItem == null)
                throw new InvalidOperationException("Item not found in cart.");

            cartItem.UpdateQuantity(quantity);
        }

        public decimal GetSubtotal()
        {
            return _items.Sum(x => x.GetLineTotal());
        }

        public decimal GetTax(decimal taxRate)
        {
            if (taxRate < 0)
                throw new ArgumentException("Tax rate cannot be negative.");

            return GetSubtotal() * taxRate;
        }

        public decimal GetTotal(decimal taxRate)
        {
            return GetSubtotal() + GetTax(taxRate);
        }

        public bool IsEmpty()
        {
            return !_items.Any();
        }

        public void Clear()
        {
            _items.Clear();
        }
    }

    public class Payment
    {
        public PaymentMethod Method { get; }
        public decimal AmountPaid { get; }

        public Payment(PaymentMethod method, decimal amountPaid)
        {
            if (amountPaid < 0)
                throw new ArgumentException("Amount paid cannot be negative.");

            Method = method;
            AmountPaid = amountPaid;
        }

        public bool IsSufficient(decimal totalAmount)
        {
            return AmountPaid >= totalAmount;
        }

        public decimal GetChange(decimal totalAmount)
        {
            if (!IsSufficient(totalAmount))
                throw new InvalidOperationException("Insufficient payment.");

            return AmountPaid - totalAmount;
        }
    }

    public class Receipt
    {
        public List<ReceiptLine> Lines { get; }
        public decimal Subtotal { get; }
        public decimal Tax { get; }
        public decimal Total { get; }
        public decimal AmountPaid { get; }
        public decimal Change { get; }
        public DateTime GeneratedAt { get; }

        public Receipt(
            List<ReceiptLine> lines,
            decimal subtotal,
            decimal tax,
            decimal total,
            decimal amountPaid,
            decimal change)
        {
            Lines = lines;
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            AmountPaid = amountPaid;
            Change = change;
            GeneratedAt = DateTime.UtcNow;
        }

        public void Print()
        {
            Console.WriteLine("======== RECEIPT ========");
            foreach (var line in Lines)
            {
                Console.WriteLine($"{line.ItemName} x{line.Quantity} - ${line.LineTotal:F2}");
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine($"Subtotal: ${Subtotal:F2}");
            Console.WriteLine($"Tax:      ${Tax:F2}");
            Console.WriteLine($"Total:    ${Total:F2}");
            Console.WriteLine($"Paid:     ${AmountPaid:F2}");
            Console.WriteLine($"Change:   ${Change:F2}");
            Console.WriteLine($"Time:     {GeneratedAt}");
            Console.WriteLine("=========================");
        }
    }

    public class ReceiptLine
    {
        public string ItemName { get; }
        public int Quantity { get; }
        public decimal UnitPrice { get; }
        public decimal LineTotal { get; }

        public ReceiptLine(string itemName, int quantity, decimal unitPrice, decimal lineTotal)
        {
            ItemName = itemName;
            Quantity = quantity;
            UnitPrice = unitPrice;
            LineTotal = lineTotal;
        }
    }


    //public class Program
    //{
    //    public static void Main()
    //    {
    //        var apple = new Item(1, "Apple", 1.50m);
    //        var milk = new Item(2, "Milk", 3.25m);
    //        var bread = new Item(3, "Bread", 2.75m);

    //        var cart = new Cart();
    //        cart.AddItem(apple, 3);
    //        cart.AddItem(milk, 1);
    //        cart.AddItem(bread, 2);

    //        var payment = new Payment(PaymentMethod.Cash, 20.00m);

    //        var posService = new PosService(0.06m); // 6% tax
    //        var receipt = posService.Checkout(cart, payment);

    //        receipt.Print();
    //    }
    //}
}

