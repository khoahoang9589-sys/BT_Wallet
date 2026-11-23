using BT_Wallet.Models;

namespace BT_Wallet.Services;

public class WalletStateService
{
    public event Action? OnChange;

    public decimal Balance { get; private set; }
    public List<Transaction> Transactions { get; } = new();

    public bool Deposit(decimal amount, out string errorMessage)
    {
        if (amount <= 0)
        {
            errorMessage = "Số tiền nạp phải lớn hơn 0.";
            return false;
        }

        Balance += amount;
        AddTransaction(TransactionType.Deposit, amount);
        OnChange?.Invoke();
        errorMessage = string.Empty;
        return true;
    }

    public bool Withdraw(decimal amount, out string errorMessage)
    {
        if (amount <= 0)
        {
            errorMessage = "Số tiền rút phải lớn hơn 0.";
            return false;
        }

        if (amount > Balance)
        {
            errorMessage = "Số tiền rút không được lớn hơn số dư hiện tại.";
            return false;
        }

        Balance -= amount;
        AddTransaction(TransactionType.Withdraw, amount);
        OnChange?.Invoke();
        errorMessage = string.Empty;
        return true;
    }

    private void AddTransaction(TransactionType type, decimal amount)
    {
        Transactions.Insert(0, new Transaction
        {
            Type = type,
            Amount = amount,
            CreatedAt = DateTime.Now
        });
    }
}
