﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto dto)
        {
            Sessao sessao = _mapper.Map<Sessao>(dto);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao=> sessao.Id == id);
            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
}
