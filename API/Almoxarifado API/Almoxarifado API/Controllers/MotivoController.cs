using Almoxarifado_API.Models;
using Almoxarifado_API.Repository;
using Almoxarifado_API.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Almoxarifado_API.Controllers
{
    public class MotivoController : ControllerBase
    {
      
        private readonly MotivoRepository _motivoRepository = new MotivoRepository();
        [HttpGet]
        [Route("TodososMotivos")]
        public IActionResult TodosDepartamentos()
        {
            return Ok(_motivoRepository.TodososMotivos());

        }
        [HttpGet]
        [Route("{id}/MotivotoPeloID")]
        public IActionResult MotivoPeloID(int id)
        {
            try
            {
                Motivo motivo = new Motivo();
                motivo.MotID = id;
                return Ok(_motivoRepository.TodososMotivos().Find(x => x.MotID == motivo.MotID));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro " + ex.Message);
            }

        }
        [HttpPost]
        [Route("AdicionarMotivo")]
        public IActionResult Adicionar(MotivoViewModel pMotivo)
        {
            try
            {
               var novoMotivo = new Motivo()
               {
                        MotDescricao = pMotivo.MotDescricao,
                        IDCategoriadoMotivo = pMotivo.IDCategoriadoMotivo
               };
                _motivoRepository.Add(novoMotivo);
                return Ok("Motivo com sucesso");

            }
            catch (Exception ex)
            {
                return Ok("Motivo não adicionado " + ex.Message);
            }


        }
        [HttpDelete]
        [Route("DeleteMotivo")]
        public IActionResult DeleteMotivo(string motivo)
        {
            try
            {
                var novoMotivo = new Motivo()
                {
                    MotDescricao = motivo,
                   
                };
                var delete = _motivoRepository.TodososMotivos().Find(x => x.MotID == novoMotivo.MotID);
                _motivoRepository.Delete(delete);
                return Ok("Motivo deletado com sucesso");

            }
            catch (Exception ex)
            {
                return Ok("Motivo não deletado " + ex.Message);
            }


        }
        [HttpPut]
        [Route("UpdateMotivo")]
        public IActionResult UpdateMotivo(Motivo pMotivo)
        {
            try
            {
                Motivo Motivo = new Motivo
                {
                    MotID = pMotivo.MotID,
                    MotDescricao = pMotivo.MotDescricao,
                    IDCategoriadoMotivo = pMotivo.IDCategoriadoMotivo
                };
               
                _motivoRepository.Update(Motivo);
                return Ok("Motivo atualizado com sucesso");

            }
            catch (Exception ex)
            {
                return Ok("Motivo não atualizado " + ex.Message);
            }


        }

    }
}
