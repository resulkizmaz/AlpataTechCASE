import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { UserLoginResult } from 'src/app/models/User.model';
import { AuthenticationService } from 'src/app/services/authentication/authentication.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit, OnDestroy {

  userData : UserLoginResult;
  constructor(private auth:AuthenticationService) {
    this.userData = auth.userData;
  }

  ngOnSubscribe = new Subject();
  ngOnInit(): void {
  }


  ngOnDestroy(): void {
    this.ngOnSubscribe.next(true);
    this.ngOnSubscribe.complete();
  }
}
