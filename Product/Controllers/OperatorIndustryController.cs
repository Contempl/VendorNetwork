using Microsoft.AspNetCore.Mvc;
using Product.Domain.Entity;
using Product.Services.Dto;
using Product.Services.Filters;
using Product.Services.Interfaces;

namespace Product.Controllers;

[Route("operator")]
[ApiController]
public class OperatorIndustryController : ControllerBase
{
	private readonly IOperatorIndustryService _operatorIndustryService;
	private readonly IOperatorService _operatorService;

	public OperatorIndustryController(IOperatorIndustryService operatorIndustryService, IOperatorService operatorService)
	{
		_operatorIndustryService = operatorIndustryService;
		_operatorService = operatorService;
	}

	[HttpGet("{operatorId}/industry/{industryId}")]
	[EnsureOperatorIndustryExists]
	public async Task<ActionResult<OperatorIndustry>> GetOperatorFacility(int operatorId, int industryId)
	{
		var industry = await _operatorIndustryService.GetByIdAsync(operatorId, industryId);

		return Ok(industry);
	}

	[HttpGet("{operatorId}/industries")]
	public async Task<ActionResult<List<OperatorIndustry>>> GetOperatorIndustries(int operatorId)
	{
		var facilities = await _operatorIndustryService.GetOperatorsIndustries(operatorId);

		return facilities.ToList();
	}

	[HttpPost("{operatorId}/industry")]
	[EnsureOperatorExists]
	public async Task<ActionResult> AddOperatorIndustry(int operatorId, [FromBody] OperatorIndustryCreationDto industryData)
	{
		var existingOperator = await _operatorService.GetByIdAsync(operatorId);

		var newIndustry = _operatorIndustryService.MapIndustryToCreateOperator(existingOperator, industryData);

		await _operatorIndustryService.CreateAsync(newIndustry);

		return CreatedAtAction(nameof(GetOperatorFacility), new {operatorId = operatorId, industryId = newIndustry.Id }, newIndustry);
	}

	[HttpPut("{operatorId}/industry/{industryId}")]
	[EnsureOperatorIndustryExists]
	public async Task<ActionResult> UpdateOperatorIndustry(int operatorId, int industryId,
		UpdateOperatorIndustryDto industryData)
	{
		var existingIndustry = await _operatorIndustryService.GetByIdAsync(operatorId, industryId);

		_operatorIndustryService.MapIndustryToUpdate(existingIndustry, industryData);

		await _operatorIndustryService.UpdateAsync(existingIndustry);
		return Ok(existingIndustry);
		
	}

	[HttpDelete("{operatorId}/industry/{industryId}")]
	[EnsureOperatorIndustryExists]
	public async Task<ActionResult> RemoveOperatorIndustry(int operatorId, int industryId)
	{
		var operatorIndustry = await _operatorIndustryService.GetByIdAsync(operatorId, industryId);

		await _operatorIndustryService.DeleteAsync(operatorIndustry);
		return NoContent();
	}
}
