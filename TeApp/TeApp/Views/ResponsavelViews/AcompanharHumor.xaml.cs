﻿using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeApp.Apis;
using TeApp.Models;
using TeApp.Models.CriancaHumor;
using TeApp.Models.Humor;
using TeApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TeApp.Views.ResponsavelViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcompanharHumor : ContentPage
    {
        private CriancaHumorApi _criancahumorApi;
        private HumorApi _humorApi;
        private ObservableCollection<CriancaHumorViewModel> _listOfHumors;
        //private 
        public AcompanharHumor()
        {
            InitializeComponent();
            _criancahumorApi = new CriancaHumorApi(new HttpClient());
            _humorApi = new HumorApi(new HttpClient());
            int idCrianca = GlobalUserModel.UserModel.idCrianca;
            GetHumorCriancas(idCrianca);
            

            //Recebe uma mensagem do Popup para dar Refreh na página
            MessagingCenter.Subscribe<App>((App)Application.Current, "OnCategoryCreated", (sender) =>
            {
                GetHumorCriancas(idCrianca);
            });
        }

        public async void GetHumorCriancas(int idCrianca)
        {
            load.IsRunning = true;
            load.IsVisible = true;
            lblnoResults.IsVisible = false;
            ListOfHumors.IsVisible = false;
            var resultado = await this._criancahumorApi.GetHumores(idCrianca); //Buscar os humores cadastrado pela criança
            var humorDescription = await this._humorApi.GetHumores();// Busca a descrição de cada humor
            var lista = new List<CriancaHumorViewModel>();
            
            if (resultado.Success)
            {
                foreach (var humor in resultado.Content) //Percorre todos os humores retornados
                {
                    var descricao = (from h in humorDescription.Content
                                     where h.id == humor.idHumor
                                     select h.descricao); //Seta a descrição de acordo com o Id do Humoer

                    var myHumor = new CriancaHumorViewModel() //Cria um novo objeto especifico para realizar o Binding na View
                    {
                        Id = humor.idHumorCrianca,
                        IdCrianca = (int)humor.idCrianca,
                        Humor = descricao.FirstOrDefault().ToString(),
                        Data = humor.data,
                        Observacao = humor.observacao,
                        HasObservacao = string.IsNullOrEmpty(humor.observacao)
                    };

                    lista.Add(myHumor); //Adiciona esse objeto em uma lista
                }

                _listOfHumors = new ObservableCollection<CriancaHumorViewModel>(lista); //Converte a lista em uma ObservableCollection que é o tipo de dado reconhecido pela CollectionView
                ListOfHumors.ItemsSource = null;
                ListOfHumors.ItemsSource = _listOfHumors;//Define essa lista como a Fonte de Dados da CollectionView
            }
            else
            {
                await DisplayAlert("Erro!", "Não foi possível carregar a lista de Humores. Tente novamente mais tarde!", "OK");
            }

            if(_listOfHumors.Count == 0)
            {
                lblnoResults.IsVisible = true;
            }
            else
            {
                lblnoResults.IsVisible = false;
            }

            load.IsRunning = false;
            load.IsVisible = false;
            ListOfHumors.IsVisible = true;
        }

        private void Btn_AddObs(object sender, EventArgs e)
        {
            var eventArgs = (Button)sender;
            var page = new Popups.PopupObservacao();
            page.BindingContext = eventArgs.CommandParameter;

            Navigation.PushPopupAsync(page);
            
        }
    }
}