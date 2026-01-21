using Match3OOAP.Helpers;

namespace Match3OOAP.GameLogic.GameGrid
{
    public struct SwapAvailabilityResult
    {
        public bool IsSwapPossible { get; }
            
        public string AvailabilityInfo { get; }

        public SwapAvailabilityResult(bool isSwapPossible, string availabilityInfo)
        {
            availabilityInfo.AssertNotNull();
                
            IsSwapPossible = isSwapPossible;
            AvailabilityInfo = availabilityInfo;
        }
    }
}