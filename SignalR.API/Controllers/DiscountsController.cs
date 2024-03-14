﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.DiscountDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IDiscountService _discountService, IMapper _mapper) : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetAll()
        {

            var result = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountDto createDiscountDto)
        {
            var newDiscount = _mapper.Map<Discount>(createDiscountDto);
            newDiscount.Status = false;
            _discountService.TAdd(newDiscount);
            return Ok("Yeni İndirim Kodu Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateDiscountDto updateDiscountDto)
        {
            var discount = _mapper.Map<Discount>(updateDiscountDto);
            discount.Status = false;
            _discountService.TUpdate(discount);
            return Ok("İndirim Kodu Güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _discountService.TDelete(id);
            return Ok("İndirim Kodu Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _discountService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("MakeActive/{id}")]
        public IActionResult MakeActive(int id)
        {
            _discountService.ChangeStatusToTrue(id);
            return Ok("Durum Aktif");
        }

        [HttpGet("MakePassive/{id}")]
        public IActionResult MakePassive(int id)
        {
            _discountService.ChangeStatusToFalse(id);
            return Ok("Durum Pasif");
        }

        [HttpGet("GetActives")]
        public IActionResult GetActives()
        {
            var values = _discountService.TGetFilteredList(x => x.Status == true);
            var actives = _mapper.Map<List<ResultDiscountDto>>(values);
            return Ok(actives);
        }

        [HttpGet("GetPassives")]
        public IActionResult GetPassives()
        {
            var values = _discountService.TGetFilteredList(x => x.Status == false);
            var passives = _mapper.Map<List<ResultDiscountDto>>(values);
            return Ok(passives);
        }


    }
}
