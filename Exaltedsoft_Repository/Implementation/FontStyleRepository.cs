using Exaltedsoft_Model;
using Exaltedsoft_Model.Entities;
using Exaltedsoft_Model.ViewModels.Response;
using Exaltedsoft_Repository.Interface;

namespace Exaltedsoft_Repository.Implementation
{
    public class FontStyleRepository : IFontStyleRepository
    {
        private readonly AppDbContext _context;
        public FontStyleRepository(AppDbContext context)
        {
            _context = context;
        }

        public int FontStyleInsert(FontStyles fontStyles)
        {
            return _context.SaveChanges();
        }

        public int FontStyleUpdate(FontStyles fontStyles)
        {
            return _context.SaveChanges();
        }

        public List<FontStylesVM> GetAllFontStyle()
        {
            var test = _context.FontStyles.ToList();
            var fontStylesVM = new List<FontStylesVM>();
            foreach (var item in test)
            {
                fontStylesVM.Add(new FontStylesVM
                {
                    Id = (Guid)item.Id,
                    FontThin = item.FontThin,
                    FontBold = item.FontBold,
                    FontExtraBold = item.FontExtraBold,
                    FontHandWritten = item.FontHandWritten,
                    FontMedium = item.FontMedium,
                    FontRegular = item.FontRegular,
                });
            }
            return fontStylesVM;
        }

        public FontStylesVM GetFontStyleById(Guid Id)
        {
            var test = _context.FontStyles.FirstOrDefault(c => c.Id == Id);
            var fontStylesVM = new FontStylesVM();

            fontStylesVM.Id = (Guid)test.Id;
            fontStylesVM.FontThin = test.FontThin;
            fontStylesVM.FontBold = test.FontBold;
            fontStylesVM.FontExtraBold = test.FontExtraBold;
            fontStylesVM.FontHandWritten = test.FontHandWritten;
            fontStylesVM.FontMedium = test.FontMedium;
            fontStylesVM.FontRegular = test.FontRegular;

            return fontStylesVM;
        }

        public int DeleteFontStyleById(Guid Id)
        {
           return _context.SaveChanges();
        }
    }
}
