import {FormControl, ɵValue} from "@angular/forms";

export class Client {
  client_Id:number = 0
  client_Name:ɵValue<FormControl<string | null>> | undefined = ""
  address:ɵValue<FormControl<string | null>> | undefined = ""
  email:ɵValue<FormControl<string | null>> | undefined = ""
  password:ɵValue<FormControl<string | null>> | undefined = ""
}
