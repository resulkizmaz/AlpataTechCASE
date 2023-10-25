import { IComponentRespond } from "./component-request.interface";

export class ResponseModel<T> {
    constructor(public data: T, public success: boolean, public message: string) {

    }
}

export class FormResponseModel<T> {
    constructor(public data: T, public success: boolean, public message: string, public responds: IComponentRespond[]) {

    }
}