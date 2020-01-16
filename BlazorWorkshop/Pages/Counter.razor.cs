using Microsoft.AspNetCore.Components;

namespace BlazorWorkshop.Pages
{
  public class CounterCode: ComponentBase
  {
    public int currentCount { get; set; }

    public void IncrementCount()
    {
      currentCount++;
    }
  }
}
