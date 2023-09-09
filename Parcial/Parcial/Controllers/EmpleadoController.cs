﻿using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;
using System;

namespace Parcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController: ControllerBase
    {
        public class iEmpleadoRepository _EmpleadoRepository;
        public EmpleadoController(iEmpleadoRepository EmpleadoRepository)
        {
            _EmpleadoRepository = EmpleadoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> getEmpleado()
        {
            return Ok(await _EmpleadoRepository.getEmpleado());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmpleadobyId(int id)
        {
            return Ok(await _EmpleadoRepository.getEmpleadoById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _EmpleadoRepository.insertEmpelado(empleado);
            return Ok(created);
        }
        [HttpPut]
        public async Task<IActionResult> updateEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update = await _EmpleadoRepository.updateEmpleado(empleado);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            return Ok(await _EmpleadoRepository.deleteEmpleado(id));
        }
    }
}
