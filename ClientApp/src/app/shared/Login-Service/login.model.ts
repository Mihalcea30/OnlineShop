import {FormControl, ɵValue} from "@angular/forms";

export class Login {
  email : ɵValue<FormControl<string | null>> | undefined = ""
  password : ɵValue<FormControl<string | null>> | undefined = ""
}
