export interface IComponentRequest<T> {
    code: string;
    content: T | null | undefined;
}

export interface IComponentRespond {
    message: string;
    messageCode: string;
    success: boolean;
}