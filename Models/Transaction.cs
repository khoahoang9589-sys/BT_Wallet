namespace BT_Wallet.Models;

public enum TransactionType
{
    Deposit,
    Withdraw
}

public class Transaction
{
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }

    public string TypeText => Type == TransactionType.Deposit ? "Nạp tiền" : "Rút tiền";
    public string TypeClass => Type == TransactionType.Deposit ? "text-success" : "text-danger";
}
