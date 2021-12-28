import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { map } from 'rxjs/operators';
import { Menu, MenuDTO, MenusDTO } from '../models/MenusDTO';

const GET_MENUS = gql`
query{
  menus{
    id
    name
    description
    coverId
    imageId
    menuitems{
      articles{
        id
        name
        description
        price
        imageId
        coverId
      }
    }
  }
}
`;

const GET_MENU = gql`
query($id: ID!){
  menu(id: $id){
    id
    name
    description
    coverId
    imageId
    menuitems{
      articles{
        id
        name
        description
        price
        imageId
        coverId
      }
    }
  }
}
`;

@Injectable({
  providedIn: 'root'
})


export class MenusCrudService {

  constructor(private apollo: Apollo) { }

  getMenus(){
    return this.apollo.watchQuery<MenusDTO>({
      query: GET_MENUS,
      fetchPolicy: 'network-only',
    }).valueChanges
  }

  getMenu(id: string){
    return this.apollo.watchQuery<MenuDTO>({
      query: GET_MENU,
      variables: {
        id
      },
      fetchPolicy: 'network-only',
    }).valueChanges
  }
}
