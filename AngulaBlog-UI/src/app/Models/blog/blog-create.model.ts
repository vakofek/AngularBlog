export class BlogCreate{

  constructor(
    public blogId: number,
    public title:string,
    public content: string,
    public applicationUserId: number,
    public userName: string,
    public publishDate:Date,
    public updateDate:Date,
    public deleteConfirm:boolean = false,
    public photoId?:number
  ){}
}
