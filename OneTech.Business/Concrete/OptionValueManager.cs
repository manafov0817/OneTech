using OneTech.Business.Abstract;
using OneTech.Data.Abstract;
using OneTech.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneTech.Business.Concrete
{
    public class OptionValueManager : IOptionValueService
    {
        private IOptionValueRepository _optionValueRepository;
        public OptionValueManager ( IOptionValueRepository optionValueRepository )
        {
            _optionValueRepository = optionValueRepository;
        }
        public void Create ( OptionValue entity )
        {
            _optionValueRepository.Create(entity);
        }

        public void Delete ( OptionValue entity )
        {
            _optionValueRepository.Delete(entity);
        }

        public List<OptionValue> GetAll ()
        {
            return _optionValueRepository.GetAll( );
        }

        public List<OptionValue> GetAllColors ()
        {
            return _optionValueRepository.GetAllColors( );
        }

        public List<OptionValue> GetAllWithOptions ()
        {
            return _optionValueRepository.GetAllWithOptions( );
        }

        public OptionValue GetById ( int id )
        {
            return _optionValueRepository.GetById(id);
        }

        public List<OptionValue> GetOptionValuesByOptionId ( int id )
        {
            return _optionValueRepository.GetOptionValuesByOptionId(id);
        }

        public void Update ( OptionValue entity )
        {
            _optionValueRepository.Update(entity);
        }
    }
}
