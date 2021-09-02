export class BlogComment{

  constructor(
    public blogComentId: number,
    public blogId: number,
    public content: string,
    public userName:string,
    public applicationUserId:number,
    public publushDate:Date,
    public updateDate:Date,
    public parentBlogCommentId?:number
  ){}
}
