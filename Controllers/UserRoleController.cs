using Microsoft.AspNetCore.Mvc;
using Newdaynewcode.Model;
using Newdaynewcode.Data;
using Newdaynewcode.Filter;

namespace Newdaynewcode.Controllers
{
    /// <summary>
    /// Controller responsible for managing userrole-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting userrole information.
    /// </remarks>
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly NewdaynewcodeContext _context;

        public UserRoleController(NewdaynewcodeContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new userrole to the database</summary>
        /// <param name="model">The userrole data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        public IActionResult Post([FromBody] UserRole model)
        {
            _context.UserRole.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of userroles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"Property": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of userroles</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.UserRole.AsQueryable();
            var result = FilterService<UserRole>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific userrole by its primary key</summary>
        /// <param name="entityId">The primary key of the userrole</param>
        /// <returns>The userrole data</returns>
        [HttpGet]
        [Route("{entityId:Guid}")]
        public IActionResult GetById([FromRoute] Guid entityId)
        {
            var entityData = _context.UserRole.FirstOrDefault(entity => entity.Id == entityId);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific userrole by its primary key</summary>
        /// <param name="entityId">The primary key of the userrole</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [Route("{entityId:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid entityId)
        {
            var entityData = _context.UserRole.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.UserRole.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific userrole by its primary key</summary>
        /// <param name="entityId">The primary key of the userrole</param>
        /// <param name="updatedEntity">The userrole data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [Route("{entityId:Guid}")]
        public IActionResult UpdateById(Guid entityId, [FromBody] UserRole updatedEntity)
        {
            if (entityId != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            var entityData = _context.UserRole.FirstOrDefault(entity => entity.Id == entityId);
            if (entityData == null)
            {
                return NotFound();
            }

            var propertiesToUpdate = typeof(UserRole).GetProperties().Where(property => property.Name != "Id").ToList();
            foreach (var property in propertiesToUpdate)
            {
                property.SetValue(entityData, property.GetValue(updatedEntity));
            }

            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}