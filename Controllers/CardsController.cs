using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testecore.Data;
using testecore.Models;
using System;

namespace testecore.Controllers{

    [ApiController]
    [Route ("v1/cards")]
    public class Cartoes_credito_digitalController : ControllerBase{

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cartoes_credito_digital>>> Get(
        [FromServices] DataContext context,
         [FromBody] Pessoas model){

             var exist = await context.Pessoa
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PES_Email == model.PES_Email);

                if (exist == null){
                    var cards = await context.Cards
                    .AsNoTracking()
                    .OrderBy(x => x.CARD_ID)
                    .ToListAsync();
                    return cards;
                }else{
                    var gerarlista = await context.Cards
                .AsNoTracking()
                .OrderBy(x => x.CARD_ID)
                .Where(x => x.CARD_PES_ID == exist.Pes_ID)
                .ToListAsync();
                return Ok(gerarlista);
                }
        }
}}
