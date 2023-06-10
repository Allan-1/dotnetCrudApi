using DotnetCRUD.Models;

namespace DotnetCRUD.Services;

public static class CommentServices
{
    private static List<CommentModel> CommentList { get; }
    private static int NextId = 3;

    static CommentServices()
    {
        CommentList = new List<CommentModel>
        {
            new CommentModel { Id = 1, Body = "Loorem Ipsums", Email = "allan@mail.com", Name = "Allan", PostId = 1},
            new CommentModel{Id = 2, Body = "Ssusnov sdisdid", Email = "muturi@mail.com", Name = "Muturi", PostId = 1}
        };
    }

    public static List<CommentModel> GetAll() => CommentList;

    public static CommentModel? Get(int id) => CommentList.FirstOrDefault(comment => comment.Id == id);

    public static void Add(CommentModel comment)
    {
        CommentList.Add(comment);
        NextId++;
    }

    public static void Delete(int id)
    {
        var comment = Get(id);
        if (comment == null)
        {
            return;
        }

        CommentList.Remove(comment);
    }

    public static void Update(CommentModel comment)
    {
        var index = CommentList.FindIndex(comments => comments.Id == comment.Id);

        if (index == -1)
        {
            return;
        }

        CommentList[index] = comment;
    }
}