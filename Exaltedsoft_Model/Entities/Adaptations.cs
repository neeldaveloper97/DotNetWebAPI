using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exaltedsoft_Model.Entities
{
    public class Adaptations : BaseModel
    {
        public bool ChoosenAdaptation { get; set; }
        public string? ThemeParam { get; set; }
        public string? ThemeLabel { get; set; }
        public Guid ThemeColorsId { get; set; }
        public string? SelectedFont { get; set; }
        public string? ProductCurve { get; set; }
        public string? ButtonCurve { get; set; }
        public string? FrameCurve { get; set; }
        public string? MaxUsers { get; set; }
        public string? MaxProductRowMobile { get; set; }
        public string? MaxProductRowDesktop { get; set; }
        public bool IsAuthorized { get; set; }
    }
}
