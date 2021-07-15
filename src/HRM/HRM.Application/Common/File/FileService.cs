using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using HRM.Database.Common;
using HRM.Model.Common;

namespace HRM.Application.Common
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _FileRepository;

        public FileService(
            IFileRepository FileRepository)
        {
            _FileRepository = FileRepository;
        }
    }
}
