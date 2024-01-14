﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.Business.Interfaces;
using SignalR.Business.Validators;
using SignalR.DTO.Dtos.AboutDtos;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _aboutService.TDelete(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult Create(CreateAboutDto createAboutDto)
        {
            var newAbout = _mapper.Map<About>(createAboutDto);
            var validator = new AboutValidator();
            var result = validator.Validate(newAbout);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            _aboutService.TAdd(newAbout);
            return Ok("Hakkımızda başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateAboutDto updateAboutDto)
        {
            var about = _mapper.Map<About>(updateAboutDto);
            var validator = new AboutValidator();
            var result = validator.Validate(about);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            _aboutService.TUpdate(about);
            return Ok("Hakkımızda başarıyla güncellendi");
        }
        
    }
}