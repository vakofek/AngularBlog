export class BlogCommentCreate{

  constructor(
    public blogComentId: number,
    public blogId: number,
    public content: string,
    public parentBlogCommentId?:number
  ){}
}
