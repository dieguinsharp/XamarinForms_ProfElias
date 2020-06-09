using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1_NossoChat.Model;

namespace App1_NossoChat.Util {
    public class MensagemDataTemplateSelector : DataTemplateSelector {
        public DataTemplate minhasMsg { get; set; }
        public DataTemplate suasMsg { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            var Usuario = UsuarioUtil.GetUsuarioLogado();
            return ((Mensagens)item).id_usuario == Usuario.id ? minhasMsg : suasMsg;
        }
    }
}
