using Microsoft.AspNetCore.Mvc;
using BlackJack.Models;

namespace BlackJack.Components
{
    public class HandDisplay : ViewComponent
    {
        public IViewComponentResult Invoke(Hand hand) => View(hand);
    }
}
