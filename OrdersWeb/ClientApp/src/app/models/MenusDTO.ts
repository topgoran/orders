//import { MenuDTO } from "./MenuDTO";

import { Article } from "./ArticleDTO";


export interface MenusDTO{
    menus: Menu[]
}

export interface MenuDTO{
    menu: Menu
}

export interface Menu{
    id: string,
    name: string,
    description: string,
    coverId: number,
    imageId: number,
    menuitems: MenuItemDTO[]
}

interface MenuItemDTO{
    articles: Article[]
}