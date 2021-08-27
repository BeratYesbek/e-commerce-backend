using Business.Abstracts;
using Business.Messages;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concretes
{
    public class CommentManager : ICommentService
    {   
        private readonly ICommentDal _commentDal;   
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public IResult Add(Comment entity)
        {
            _commentDal.Add(entity);
            return new SuccessResult(CommentMessages.CommentAddSuccessMessage);
        }

        public IResult Delete(Comment entity)
        {
            _commentDal.Delete(entity);
            return new SuccessResult(CommentMessages.CommentDeleteSuccessMessage);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            var result = _commentDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Comment>>(result);
            }
            return new ErrorDataResult<List<Comment>>(null);
        }

        public IDataResult<Comment> GetById(int id)
        {
            var result = _commentDal.Get(c => c.Id == id);  
            if (result != null)
            {
                return new SuccessDataResult<Comment>(result);  
            }

            return new ErrorDataResult<Comment>(null);
        }

        public IResult Update(Comment entity)
        {
            _commentDal.Update(entity); 
            return new SuccessResult(CommentMessages.CommentUpdateSuccessMessage);  
        }
    }
}
