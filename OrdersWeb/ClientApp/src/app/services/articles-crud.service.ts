import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { ArticleCreateDTO } from '../models/ArticleCreateDTO';
import { Article, ArticleDTO } from '../models/ArticleDTO';

const GET_ARTICLE = gql`
query($id: ID!){
  article(id: $id){
    id
    name
    description
    price
    coverId
    imageId
  }
}
`;

const CREATE_ARTICLE = gql`
mutation($article: articleInput!){
  createArticle(article: $article){
    id
  }
}
`;

const CREATE_MENU_ITEM = gql`
mutation($menuItem: menuItemInput!){
  createMenuItem(menuItem: $menuItem){
    id
  }
}
`;

const UPDATE_ARTICLE = gql`
mutation($article: articleInput!, $articleId: ID!){
  updateArticle(article: $article, articleId: $articleId){
    id
  }
}
`;

const DELETE_ARTICLE = gql`
mutation($articleId: ID!){
  deleteArticle(articleId: $articleId)
}
`;


@Injectable({
  providedIn: 'root'
})
export class ArticlesCrudService {

  constructor(private apollo: Apollo) { }

  
  getArticle(id: string){
    return this.apollo.watchQuery<ArticleDTO>({
      query: GET_ARTICLE,
      variables: {
        id
      },
      fetchPolicy: 'network-only',
    }).valueChanges
  }

  addNewArticle(article: ArticleCreateDTO){
    return this.apollo.mutate({
      mutation: CREATE_ARTICLE,
      variables: {
        article
      },
      optimisticResponse: {
        createArticle: {
          id: 'String'
        }
      },
    });
  }

  addArticleToMenu(menuId: string, articleId: string){
    let menuItem = {
      menuId: menuId,
      articleId: articleId
    }

    return this.apollo.mutate({
      mutation: CREATE_MENU_ITEM,
      variables: {
        menuItem
      },
      optimisticResponse: {
        createArticle: {
          id: 'String'
        }
      },
    });
  }

  updateArticle(articleId: string, article: ArticleCreateDTO){
    return this.apollo.mutate({
      mutation: UPDATE_ARTICLE,
      variables: {
        article,
        articleId
      },
      optimisticResponse: {
        createArticle: {
          id: 'String'
        }
      },
    });
  }

  deleteArticle(articleId: string){
    return this.apollo.mutate({
      mutation: DELETE_ARTICLE,
      variables: {
        articleId
      },
      optimisticResponse: {
          deleteArticle: 'Boolean'
      },
    });
  }
}
