import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';
import { ToasterService } from 'src/app/toaster.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent implements OnInit, OnDestroy {
  formGroup: FormGroup;
  hide: boolean;

  constructor(private router: Router, private auth: AuthenticationService,private toastr:ToasterService) {
    this.hide = true;
    this.formGroup = new FormGroup({
      email: new FormControl('', [
        Validators.required,
        Validators.maxLength(255),
        Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/),
      ]),

      password: new FormControl('', [
        Validators.required,
        Validators.maxLength(64),
        Validators.pattern(/^(?='.*[a-z])(?=.*[A-Z])(?=.*\d).+$/),
      ]),

      passwordRepeat: new FormControl('', [Validators.required]),

      name: new FormControl('', [
        Validators.required,
        Validators.maxLength(64),
        Validators.pattern(/^[a-zA-Z ĞÜŞİÖÇğüşıöç]{2,100}$/),
      ]),

      surname: new FormControl('', [
        Validators.required,
        Validators.pattern(/^[a-zA-Z ĞÜŞİÖÇğüşıöç]{2,128}$/),
      ]),

      phone: new FormControl('', [
        Validators.required,
        Validators.pattern(
          /^(0)([23458]{1})([0-9]{2})\s?([0-9]{3})\s?([0-9]{2})\s?([0-9]{2})$/
        ),
      ])
    });
  }

  ngOnSubscribe = new Subject();
  ngOnInit(): void {}

  ngOnDestroy(): void {
    this.ngOnSubscribe.next(true);
    this.ngOnSubscribe.complete();
  }

  checkPassword(): boolean {
    if (
      this.formGroup.controls['password'].value &&
      this.formGroup.controls['passwordRepeat'].value &&
      this.formGroup.controls['password'].value ==
        this.formGroup.controls['passwordRepeat'].value
    )
      return true;

    // 2 şifre aynı değilse kendimiz bir error tipi oluşturuyoruz.
    this.formGroup.controls['passwordRepeat'].setErrors({ verification: true });
    return false;
  }

  //devam edecek
  registerUser() {
    if (this.checkPassword() && this.formGroup.valid) {
      const formData = new FormData();

      formData.append('email', this.formGroup.controls['email'].value);
      formData.append('password', this.formGroup.controls['password'].value);
      formData.append('name', this.formGroup.controls['name'].value);
      formData.append('surname', this.formGroup.controls['surname'].value);
      formData.append('phone', this.formGroup.controls['phone'].value);
      this.postRegister(formData);
    }
  }

  postRegister(data: FormData) {
    this.auth
      .registerMerchant(data)
      .pipe(takeUntil(this.ngOnSubscribe))
      .subscribe({
        next: (response) => {
          if(response.success){
            this.toastr.success(`Kayır Başarılı. Hoş Geldiniz Sayın ${response.name}.`,'Success');
            this.router.navigateByUrl('log-in');
          }
          this.toastr.error('Kayıt Yapılamadı.','Error');
        },
        error: (err) => {
          console.warn(err);
        },
      });
  }

  getMessage(
    message:
      | 'email'
      | 'password'
      | 'passwordRepeat'
      | 'name'
      | 'surname'
      | 'phone'
      | 'image'
  ) {
    switch (message) {
      case 'email':
        if (this.formGroup.controls['email'].hasError('required'))
          return 'Email alanı boş bırakılamaz.';
        else if (this.formGroup.controls['email'].hasError('maxlength'))
          return 'Email en fazla 255 karakterden oluşmalıdır.';
        else if (this.formGroup.controls['email'].hasError('pattern'))
          return 'Email geçersiz.';
        else return '';
      case 'password':
        if (this.formGroup.controls['password'].hasError('required'))
          return 'Şifre alanı boş bırakılamaz.';
        else if (this.formGroup.controls['password'].hasError('maxlength'))
          return 'Şifre en fazla 64 karakterden oluşmalıdır.';
        else if (this.formGroup.controls['password'].hasError('pattern'))
          return 'Şifre zayıf \'@.$!%*?&+-.\'';
        else return '';
      case 'passwordRepeat':
        if (this.formGroup.controls['passwordRepeat'].hasError('required'))
          return 'Şifre tekrar alanı boş bırakılamaz.';
        else if (
          this.formGroup.controls['passwordRepeat'].hasError('verification')
        )
          return 'Şifreler eşleşmiyor!';
        else return '';
      case 'name':
        if (this.formGroup.controls['name'].hasError('required'))
          return 'Şahıs adı boş bırakılamaz.';
        else if (this.formGroup.controls['name'].hasError('pattern'))
          return 'Şahıs adı geçersiz.';
        else return '';
      case 'surname':
        if (this.formGroup.controls['surname'].hasError('required'))
          return 'Şahıs soyadı boş bırakılamaz.';
        else if (this.formGroup.controls['surname'].hasError('pattern'))
          return 'Şahıs soyadı geçersiz.';
        else return '';
      case 'phone':
        if (this.formGroup.controls['phone'].hasError('required'))
          return 'Yetkili cep telefonu boş bırakılamaz.';
        else if (this.formGroup.controls['phone'].hasError('pattern'))
          return 'Telefon numarası geçersiz.';
        else return '';
      case 'image':
        if (this.formGroup.controls['image'].hasError('required'))
          return 'Profil resmi boş bırakılamaz.';
        else return '';
    }
  }
}
