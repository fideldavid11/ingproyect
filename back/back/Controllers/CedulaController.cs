using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CedulaController : ControllerBase
    {
        private readonly ICedulaRepository _cedulaRepository;
        private readonly IFileService _fileService;

        public CedulaController(ICedulaRepository cedulaRepository, IFileService fileService)
        {
            _cedulaRepository = cedulaRepository;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult GetAllCedulas()
        {
            try
            {
                var cedulas = _cedulaRepository.GetAll();
                return Ok(cedulas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCedulaById(int id)
        {
            try
            {
                var cedula = _cedulaRepository.GetById(id);
                if (cedula == null)
                {
                    return NotFound();
                }
                return Ok(cedula);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateCedula([FromForm] Cedula cedula)
        {
            try
            {
                if (cedula.ImageFile != null)
                {
                    var result = _fileService.SaveImage(cedula.ImageFile);
                    if (result.Item1 == 1)
                    {
                        cedula.Foto = result.Item2;
                    }
                    else
                    {
                        return BadRequest(result.Item2);
                    }
                }

                if (_cedulaRepository.Add(cedula))
                {
                    return Ok("Cedula created successfully");
                }
                else
                {
                    return BadRequest("Failed to create cedula");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCedula(int id, [FromForm] Cedula cedula)
        {
            try
            {
                var existingCedula = _cedulaRepository.GetById(id);
                if (existingCedula == null)
                {
                    return NotFound();
                }

                existingCedula.CedulaNumber = cedula.CedulaNumber;
                existingCedula.FullName = cedula.FullName;
                existingCedula.FechaNacimiento = cedula.FechaNacimiento;
                existingCedula.Nacionalidad = cedula.Nacionalidad;
                existingCedula.Sexo = cedula.Sexo;
                existingCedula.TipoSangre = cedula.TipoSangre;
                existingCedula.EstadoCivil = cedula.EstadoCivil;
                existingCedula.Ocupacion = cedula.Ocupacion;
                existingCedula.FechaExpiracion = cedula.FechaExpiracion;
                existingCedula.ColegioElectoral = cedula.ColegioElectoral;
                existingCedula.UbicacionColegio = cedula.UbicacionColegio;
                existingCedula.DireccionResidencia = cedula.DireccionResidencia;
                existingCedula.Sector = cedula.Sector;
                existingCedula.Municipio = cedula.Municipio;

                if (cedula.ImageFile != null)
                {
                    var result = _fileService.SaveImage(cedula.ImageFile);
                    if (result.Item1 == 1)
                    {
                        if (!string.IsNullOrEmpty(existingCedula.Foto))
                        {
                            _fileService.DeleteImage(existingCedula.Foto);
                        }

                        existingCedula.Foto = result.Item2;
                    }
                    else
                    {
                        return BadRequest(result.Item2);
                    }
                }

                if (_cedulaRepository.Update(existingCedula))
                {
                    return Ok("Cedula updated successfully");
                }
                else
                {
                    return BadRequest("Failed to update cedula");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCedula(int id)
        {
            try
            {
                var existingCedula = _cedulaRepository.GetById(id);
                if (existingCedula == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrEmpty(existingCedula.Foto))
                {
                    _fileService.DeleteImage(existingCedula.Foto);
                }

                if (_cedulaRepository.Delete(existingCedula))
                {
                    return Ok("Cedula deleted successfully");
                }
                else
                {
                    return BadRequest("Failed to delete cedula");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("getImage/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            try
            {
                var contentPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);
                var fileBytes = System.IO.File.ReadAllBytes(contentPath);
                return File(fileBytes, "image/jpeg");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("GetByCedulaNumber/{cedulaNumber}")]
        public IActionResult GetCedulaByCedulaNumber(string cedulaNumber)
        {
            try
            {
                var cedula = _cedulaRepository.GetByCedulaNumber(cedulaNumber);
                if (cedula == null)
                {
                    return Ok(new { exists = false });
                }
                return Ok(new { exists = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

    }
}

