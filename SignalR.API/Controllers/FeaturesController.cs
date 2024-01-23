using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.FeatureDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService _featureService, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDto createFeatureDto)
        {
            var newFeature = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(newFeature);
            return Ok("Yeni Öne Çıkan Bilgisi Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDto updateFeatureDto)
        {
            var feature = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(feature);
            return Ok("Öne Çıkan Bilgisi Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _featureService.TDelete(id);
            return Ok("Öne Çıkan Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _featureService.TGetById(id);
            return Ok(value);
        }
    }
}
