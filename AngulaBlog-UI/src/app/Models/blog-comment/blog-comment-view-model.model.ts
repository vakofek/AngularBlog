export class BlogCommentViewModel{

  constructor(
    public parentBlogCommentId:number,
    public blogComentId: number,
    public content: string,
    public blogId: number,
    public userName:string,
    public publushDate:Date,
    public updateDate:Date,
    public applicationUserId:number,
    public isEditable : boolean,
    public deleteConfirm : boolean,
    public isRepling:boolean,
public comment:BlogCommentViewModel[]
  ){}
}
