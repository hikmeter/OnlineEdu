using AutoMapper;
using FluentValidation;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Dto.Dtos.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Concrete
{
    public class SubscriberService(IRepository<Subscriber> _repository, IMapper _mapper, IValidator<CreateSubscriberDto> _createValidator, IValidator<UpdateSubscriberDto> _updateValidator) : ISubscriberService
    {
        public async Task CreateSubscriber(CreateSubscriberDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = _mapper.Map<Subscriber>(dto);
            await _repository.CreateAsync(result);
        }

        public async Task DeleteSubscriber(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);
        }

        public async Task<GetSubscriberByIdDto> GetSubscriberById(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return _mapper.Map<GetSubscriberByIdDto>(value);
        }

        public async Task<List<ResultSubscriberDto>> GetSubscriberList()
        {
            var values = await _repository.GetListAsync();
            return _mapper.Map<List<ResultSubscriberDto>>(values);
        }

        public async Task UpdateSubscriber(UpdateSubscriberDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var value = _mapper.Map<Subscriber>(dto);
            await _repository.UpdateAsync(value);
        }
    }
}
