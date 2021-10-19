using AcademyEFPersistance.EFContext;
using AcademyModel.Entities;
using AcademyModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEFPersistance.Repository
{
	public class EFAreaRepository : EFCrudRepository<Area, long>, IAreaRepository
	{
		public EFAreaRepository(AcademyContext ctx) : base(ctx)
		{
		}
	}
}
