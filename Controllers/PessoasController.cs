using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testecore.Data;
using testecore.Models;

namespace testecore.Controllers
{
    [ApiController]
    [Route("v1/pessoas")]

    public class PessoasController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Pessoas>>> Get([FromServices] DataContext context)
        {
            var pessoa = await context.Pessoa.ToListAsync();
            return pessoa;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Pessoas>> Post(
            [FromServices] DataContext context,
            [FromBody] Pessoas model
            )
        {
            if (ModelState.IsValid)
            {

                var exist = await context.Pessoa
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PES_Email == model.PES_Email );

                var pegarid = false;

               if (exist == null){
                        context.Pessoa.Add(model);
                        await context.SaveChangesAsync();      
                }else{
                    pegarid = true;
                }

                var random = new Random();
                const string pool = "0123456789";
                var builder = new StringBuilder();
                for (var i = 0; i < 16; i++)
                {
                    var c = pool[random.Next(0, pool.Length)];
                    builder.Append(c);
                }
                var cn = builder.ToString();
                cn = String.Format("{0:0000 0000 0000 0000}", (Int64.Parse(cn)));
                
               if (pegarid == true){
                    var cartoes = new Cartoes_credito_digital { CARD_Number = cn, 
                    CARD_PES_ID = exist.Pes_ID };
                    context.Cards.Add(cartoes);
                    await context.SaveChangesAsync();
               } else {
                   var cartoes = new Cartoes_credito_digital { CARD_Number = cn, CARD_PES_ID
                    = model.Pes_ID };
                   context.Cards.Add(cartoes);
                    await context.SaveChangesAsync();
               }
                
                return Ok(cn);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

    }

}
