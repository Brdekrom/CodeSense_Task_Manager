using CodeSense.Application.Abstractions;
using CodeSense.Domain.Entities;
using CodeSense.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CodeSense.Infrastructure.Repositories
{
    public sealed class CompanyRepository(CodeSenseDbContext context) : IRepository<Company>
    {
        private readonly CodeSenseDbContext _dbContext = context;

        public async Task<Company> CreateAsync(Company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();

            var createdCompany = await GetByEmailAsync(company.ContactData.PrimaryEmail);
            return createdCompany;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company is null)
            {
                return false;
            }

            company.IsDeleted = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await _dbContext.Companies.Where(x => !x.IsDeleted).ToListAsync();
            return companies;
        }

        public async Task<Company> GetByEmailAsync(string email)
        {
            var company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.ContactData.PrimaryEmail == email && !x.IsDeleted);
            return company;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var company = await _dbContext.Companies.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
            return company ?? throw new NullReferenceException("Company not found");
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            _dbContext.Companies.Update(company);
            await _dbContext.SaveChangesAsync();
            return company;
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}