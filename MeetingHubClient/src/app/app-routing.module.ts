import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DefaultComponent } from './home/default/default.component';
import { SignUpComponent } from './home/default/sign-up/sign-up.component';
import { SignInComponent } from './home/default/sign-in/sign-in.component';
import { HomePageComponent } from './home/default/home-page/home-page.component';



@NgModule({
  imports: [RouterModule.forRoot(AppRoutingModule.getRoutes())],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor() {}

  public static getRoutes(){
    const routes: Routes = [
      {
        path:'',
        component: DefaultComponent,
        children: [{
          path:'sign-in',
          component:SignInComponent,
          children:[{
            path:'authorised',
            component: HomePageComponent
          },{
            path:'unauthorised',
            component: DefaultComponent
          }]
        },{
          path: 'sign-up',
          component:SignUpComponent
        }]
      }





    ];
    return routes;
  }


 }
