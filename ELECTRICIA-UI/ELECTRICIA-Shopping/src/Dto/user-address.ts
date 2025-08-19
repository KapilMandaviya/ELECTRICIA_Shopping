export class UserAddress {
    AddId:number=0
    UserId:number=0
    AddressType:string=""
    StreetName:string=""
    CityId:string=""
    ZipCode:number=0
    CreatedDate!:Date
    CreatedByUserId!:string
    UpdatedDate!:Date
    DeletedDate!:Date
    IsDelete!:boolean
    ModifyAction!:string
}
