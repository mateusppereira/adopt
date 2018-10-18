import { call, put } from 'redux-saga/effects';
import { NavigationActions } from 'react-navigation';
import { Creators as DonationActions } from 'store/ducks/donation';
import axios from 'axios';

export function* get() {
  try {
    // const response = yield call(axios.get, 'http://www.mocky.io/v2/5bb554833000006d00aabcf9');
    const response = {
      data: {
        hasErrors: false,
        message: "",
        objectResult: [
          {
            "cdDonation": "5bc8ddf97ec5191455c9c386",
            "title": "Holmes",
            "description": "Ex in aliquip dolor ut do Lorem deserunt do nulla eu est veniam. Cupidatat labore est non sunt velit laborum aliqua laboris fugiat ad dolore.",
            "fkUser": 26,
            "user": {
              "name": "Mcleod",
              "phone": "(800) 402-3041"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf97b567f315de9fdeb",
            "title": "Carter",
            "description": "Ex sit nisi elit duis. Qui tempor magna incididunt dolore est nisi. Esse ex excepteur est voluptate. Pariatur fugiat elit id consectetur",
            "fkUser": 27,
            "user": {
              "name": "Roxanne",
              "phone": "(804) 451-3417"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf9e9af6cf381915886",
            "title": "Felecia",
            "description": "Pariatur laboris occaecat ut laboris occaecat aliqua incididunt. Culpa minim officia nostrud eu commodo pariatur excepteur. Commodo",
            "fkUser": 28,
            "user": {
              "name": "Mullins",
              "phone": "(970) 556-2859"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf9d7e76186b18f2864",
            "title": "Adele",
            "description": "Deserunt et nostrud ea adipisicing aliquip. Ipsum commodo ipsum commodo id laboris ex consequat ipsum mollit qui aliquip. Do except",
            "fkUser": 28,
            "user": {
              "name": "Frederick",
              "phone": "(855) 542-2468"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf95001b2678112be46",
            "title": "Janice",
            "description": "Eu irure qui sint Lorem adipisicing mollit magna adipisicing commodo dolore. Voluptate reprehenderit mollit do laborum dolore esse ",
            "fkUser": 38,
            "user": {
              "name": "Nona",
              "phone": "(856) 553-2808"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf9c1c9150af2a503b2",
            "title": "Tina",
            "description": "Fugiat officia ullamco dolore nisi do ad ad Lorem in adipisicing quis consectetur qui. Magna proident ullamco duis veniam ex officia",
            "fkUser": 36,
            "user": {
              "name": "Padilla",
              "phone": "(894) 451-3520"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf971afc51e1a6b6072",
            "title": "Dawson",
            "description": "Qui cillum quis adipisicing culpa dolore minim id. Elit velit aliquip ea qui occaecat. Dolore consectetur pariatur et ullamco minim non exercitation cillum anim.",
            "fkUser": 29,
            "user": {
              "name": "Petty",
              "phone": "(985) 542-2647"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf9320e305c52241e34",
            "title": "Mcdaniel",
            "description": "Sit in nisi minim proident esse esse eiusmod non culpa et nulla cupidatat veniam. Occaecat minim amet aute est magna sint.",
            "fkUser": 36,
            "user": {
              "name": "Soto",
              "phone": "(828) 497-3797"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf99a7ec0df33b80f35",
            "title": "Juliet",
            "description": "Dolore quis proident reprehenderit magna. Aliquip fugiat occaecat sunt id veniam est cillum ut Lorem voluptate.",
            "fkUser": 37,
            "user": {
              "name": "Tami",
              "phone": "(869) 401-2639"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          },
          {
            "cdDonation": "5bc8ddf9f93d181b4c272279",
            "title": "Erma",
            "description": "Quis proident commodo mollit est pariatur. Aute fugiat qui irure veniam in. Cillum excepteur consequat ",
            "fkUser": 31,
            "user": {
              "name": "Donovan",
              "phone": "(817) 408-2945"
            },
            "gender": "Masculino",
            "specie": "Cachorro",
            "geom": "POINT(-43.12334 -31.42322)",
            "photos": [
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              },
              {
                "photo": "https://t1.ea.ltmcdn.com/pt/images/5/3/1/o_que_fazer_se_o_meu_cachorro_esta_estressado_20135_600.jpg"
              }
            ]
          }
        ],
      }
    }
    if (response.data.hasErrors) {
      yield put(DonationActions.getFailure(response.data.message));      
    } else {
      yield put(DonationActions.getSuccess(response.data.objectResult));
    }
  } catch (error) {
    yield put(DonationActions.getFailure('Erro'));
  }
}
