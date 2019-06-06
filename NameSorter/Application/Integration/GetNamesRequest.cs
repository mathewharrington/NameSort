using System;
namespace NameSorter.Application.Integration
{
    public class GetNamesRequest
    {
        public string Directory { get; set; }
        public string FileName { get; set; }

        public GetNamesRequest()
        {

        }
    }
}
