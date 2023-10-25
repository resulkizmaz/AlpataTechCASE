export interface IComponentRequest<T> { //backend'e giden yapı
    code: string;
    content: T | null | undefined;
}
export interface IComponentRespond { //backend'den gelecek olan yapı
    message: string;
    messageCode: string;
    success: boolean;
}
