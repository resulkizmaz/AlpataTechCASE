import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { UserLoginRequest } from 'src/app/models/User.model';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent implements OnInit, OnDestroy {
  hide: boolean;
  formGroup : FormGroup;
  constructor() {
    this.hide = true;
    this.formGroup = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
        Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/)]),
        
      password: new FormControl('', [
        Validators.required,
        Validators.maxLength(64),
        Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$/)])});
  }
 
  ngOnSubscribe = new Subject();
  ngOnInit(): void {


  }

  logInRequest(data : UserLoginRequest){
    
  }
  
  getMessage(
    message: 'email' | 'password') {
      switch (message) {
        case 'email':
          if (this.formGroup.controls['email'].hasError('required')) return 'Email alanı boş bırakılamaz.';
          else if (this.formGroup.controls['email'].hasError('maxlength')) return 'Email en fazla 255 karakterden oluşmalıdır.';
          else if (this.formGroup.controls['email'].hasError('pattern')) return 'Email geçersiz.';
          else return '';   
        case 'password':
          if (this.formGroup.controls['password'].hasError('required')) return 'Şifre alanı boş bırakılamaz.';
          else if (this.formGroup.controls['password'].hasError('maxlength')) return 'Şifre en fazla 64 karakterden oluşmalıdır.';
          else if (this.formGroup.controls['password'].hasError('pattern')) return 'Şifre en az bir küçük harf, bir büyük harf, bir rakam ve bir sembol içermelidir. İzin verilen semboller @.$!%*?&+-.';
          else return '';      
    }
  }



  ngOnDestroy(): void {
    this.ngOnSubscribe.next(true);
    this.ngOnSubscribe.complete();
  }
}
