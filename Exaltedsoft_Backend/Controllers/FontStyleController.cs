using Exaltedsoft_Model.ViewModels.Response;
using Exaltedsoft_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Exaltedsoft_Backend.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class FontStyleController : Controller
    {
        private readonly IFontStyleService _fontStyleService;

        public FontStyleController(IFontStyleService fontStyleService)
        {
            _fontStyleService = fontStyleService;
        }

        [HttpPost]
        [Route("SaveFontStyle")]
        public IActionResult SaveFontStyle(FontStylesVM fontStyles)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                if (fontStyles != null)
                {
                    var result = _fontStyleService.FontStyleInsert(fontStyles);
                    if (result == 1)
                    {
                        commonResponse.status = 1;
                        commonResponse.message = "success";
                    }
                    else
                    {
                        commonResponse.message = "fail";
                    }
                }
                else
                {
                    commonResponse.message = "Data should not be null";
                }
            }
            catch (Exception ex)
            {
                commonResponse.message = ex.Message;
            }
            return Ok(commonResponse);
        }

        [HttpPut]
        [Route("UpdateFontStyle")]
        public IActionResult UpdateFontStyle(FontStylesVM fontStyles)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                if (fontStyles != null)
                {
                    var result = _fontStyleService.FontStyleUpdate(fontStyles);
                    if (result != 0)
                    {
                        commonResponse.status = 1;
                        commonResponse.message = "success";
                    }
                    else
                    {
                        commonResponse.message = "fail";
                    }
                }
                else
                {
                    commonResponse.message = "Data should not be null";
                }
            }
            catch (Exception ex)
            {
                commonResponse.message = ex.Message;
            }
            return Ok(commonResponse);
        }

        [HttpGet]
        [Route("GetAllFontStyle")]
        public IActionResult GetAllFontStyle()
        {
            CommonResponse<List<FontStylesVM>> commonResponse = new CommonResponse<List<FontStylesVM>>();
            try
            {
                var result = _fontStyleService.GetAllFontStyle();
                if (result.Any())
                {
                    commonResponse.data = result;
                    commonResponse.status = 1;
                    commonResponse.message = "success";
                }
                else
                {
                    commonResponse.message = "No data found";
                }
            }
            catch (Exception ex)
            {
                commonResponse.message = ex.Message;
            }
            return Ok(commonResponse);
        }

        [HttpGet]
        [Route("GetFontStyleById")]
        public IActionResult GetFontStyleById(Guid Id)
        {
            CommonResponse<FontStylesVM> commonResponse = new CommonResponse<FontStylesVM>();
            try
            {
                if (Id != Guid.Empty)
                {
                    var result = _fontStyleService.GetFontStyleById(Id);
                    if (result != null)
                    {
                        commonResponse.data = result;
                        commonResponse.status = 1;
                        commonResponse.message = "success";
                    }
                    else
                    {
                        commonResponse.message = "No data found";
                    }
                }
                else
                {
                    commonResponse.message = "Id should not be null";
                }
            }
            catch (Exception ex)
            {
                commonResponse.message = ex.Message;
            }
            return Ok(commonResponse);
        }

        [HttpDelete]
        [Route("DeleteFontStyleById")]
        public IActionResult DeleteFontStyleById(Guid Id)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                if (Id != Guid.Empty)
                {
                    var result = _fontStyleService.DeleteFontStyleById(Id);
                    if (result != 0)
                    {
                        commonResponse.status = 1;
                        commonResponse.message = "success";
                    }
                    else
                    {
                        commonResponse.message = "fail";
                    }
                }
                else
                {
                    commonResponse.message = "Id should not be null";
                }
            }
            catch (Exception ex)
            {
                commonResponse.message = ex.Message;
            }
            return Ok(commonResponse);
        }
    }
}
