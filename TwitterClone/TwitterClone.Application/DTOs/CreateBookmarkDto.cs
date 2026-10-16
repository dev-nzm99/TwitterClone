using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.DTOs
{
    public class CreateBookmarkDto
    {
        public required Guid UserId {  get; set; }
        public required Guid TweetId { get; set; }
    }
}
