namespace Gilgamesh.Entities.Instruments
{
    public class CashInstrument : Instrument
    {
        public override char GetInstrumentType()
        {
            return 'C';
        }
    }
}