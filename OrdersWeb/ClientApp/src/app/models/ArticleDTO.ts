

export interface ArticleDTO{
    article: Article
}

export interface Article{
    id: string,
    name: string,
    description: string,
    price: number,
    imageId: number,
    coverId: number
}