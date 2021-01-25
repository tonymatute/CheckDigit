namespace API.Interface
{
    public interface ICheckDigitRepository
    {
        int calculateCheckDigit(long trackingNumber);
    }
}
