using ProjetoDA.modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDA.models
{
    public class AppDbInitializer: DropCreateDatabaseIfModelChanges<ShoppingContext>
    {
        protected override void Seed(ShoppingContext context)
        {
            // 1. Criar Tipos de Artigo
            TipoArtigo tipoMercearia = new TipoArtigo("Mercearia");
            TipoArtigo tipoTalho = new TipoArtigo("Talho");
            TipoArtigo tipoPeixaria = new TipoArtigo("Peixaria");
            TipoArtigo tipoFrutaria = new TipoArtigo("Frutas e Legumes");
            TipoArtigo tipoLimpeza = new TipoArtigo("Limpeza Doméstica");
            TipoArtigo tipoHigiene = new TipoArtigo("Higiene Pessoal");
            TipoArtigo tipoAnimais = new TipoArtigo("Animais");
            TipoArtigo tipoEletronica = new TipoArtigo("Eletrónica");
            TipoArtigo tipoRoupa = new TipoArtigo("Vestuário");

            context.TiposArtigo.Add(tipoMercearia);
            context.TiposArtigo.Add(tipoTalho);
            context.TiposArtigo.Add(tipoPeixaria);
            context.TiposArtigo.Add(tipoFrutaria);
            context.TiposArtigo.Add(tipoLimpeza);
            context.TiposArtigo.Add(tipoHigiene);
            context.TiposArtigo.Add(tipoAnimais);
            context.TiposArtigo.Add(tipoEletronica);
            context.TiposArtigo.Add(tipoRoupa);

            // 2. Criar Artigos (Mínimo de 10 por cada categoria)

            // --- MERCEARIA ---
            context.Artigos.Add(new Artigo("Arroz Agulha 1kg", tipoMercearia));
            context.Artigos.Add(new Artigo("Massa Esparguete 500g", tipoMercearia));
            context.Artigos.Add(new Artigo("Leite Meio Gordo 1L", tipoMercearia));
            context.Artigos.Add(new Artigo("Azeite Virgem Extra 75cl", tipoMercearia));
            context.Artigos.Add(new Artigo("Óleo Alimentar 1L", tipoMercearia));
            context.Artigos.Add(new Artigo("Café Moído 250g", tipoMercearia));
            context.Artigos.Add(new Artigo("Açúcar Branco 1kg", tipoMercearia));
            context.Artigos.Add(new Artigo("Farinha de Trigo 1kg", tipoMercearia));
            context.Artigos.Add(new Artigo("Lata de Atum Posta", tipoMercearia));
            context.Artigos.Add(new Artigo("Feijão Manteiga Cozido", tipoMercearia));

            // --- TALHO ---
            context.Artigos.Add(new Artigo("Peito de Frango", tipoTalho));
            context.Artigos.Add(new Artigo("Carne Picada de Vaca", tipoTalho));
            context.Artigos.Add(new Artigo("Bifes de Peru", tipoTalho));
            context.Artigos.Add(new Artigo("Costeletas de Porco", tipoTalho));
            context.Artigos.Add(new Artigo("Entremeada", tipoTalho));
            context.Artigos.Add(new Artigo("Fêveras de Porco", tipoTalho));
            context.Artigos.Add(new Artigo("Perna de Frango", tipoTalho));
            context.Artigos.Add(new Artigo("Carne de Vaca para Estufar", tipoTalho));
            context.Artigos.Add(new Artigo("Chouriço de Carne", tipoTalho));
            context.Artigos.Add(new Artigo("Salsichas Frescas", tipoTalho));

            // --- PEIXARIA ---
            context.Artigos.Add(new Artigo("Postas de Bacalhau", tipoPeixaria));
            context.Artigos.Add(new Artigo("Lombos de Salmão", tipoPeixaria));
            context.Artigos.Add(new Artigo("Dourada Fresca", tipoPeixaria));
            context.Artigos.Add(new Artigo("Robalo Fresco", tipoPeixaria));
            context.Artigos.Add(new Artigo("Medalhões de Pescada", tipoPeixaria));
            context.Artigos.Add(new Artigo("Sardinha", tipoPeixaria));
            context.Artigos.Add(new Artigo("Polvo Limpo", tipoPeixaria));
            context.Artigos.Add(new Artigo("Camarão Cozido", tipoPeixaria));
            context.Artigos.Add(new Artigo("Argolas de Lula", tipoPeixaria));
            context.Artigos.Add(new Artigo("Atum Fresco", tipoPeixaria));

            // --- FRUTAS E LEGUMES ---
            context.Artigos.Add(new Artigo("Maçã Gala", tipoFrutaria));
            context.Artigos.Add(new Artigo("Banana da Madeira", tipoFrutaria));
            context.Artigos.Add(new Artigo("Pera Rocha", tipoFrutaria));
            context.Artigos.Add(new Artigo("Laranja do Algarve", tipoFrutaria));
            context.Artigos.Add(new Artigo("Limão", tipoFrutaria));
            context.Artigos.Add(new Artigo("Batata Branca", tipoFrutaria));
            context.Artigos.Add(new Artigo("Cebola", tipoFrutaria));
            context.Artigos.Add(new Artigo("Alho", tipoFrutaria));
            context.Artigos.Add(new Artigo("Cenoura", tipoFrutaria));
            context.Artigos.Add(new Artigo("Alface Lisa", tipoFrutaria));

            // --- LIMPEZA DOMÉSTICA ---
            context.Artigos.Add(new Artigo("Detergente da Loiça Manual", tipoLimpeza));
            context.Artigos.Add(new Artigo("Detergente da Loiça Máquina", tipoLimpeza));
            context.Artigos.Add(new Artigo("Detergente da Roupa em Pó", tipoLimpeza));
            context.Artigos.Add(new Artigo("Amaciador da Roupa", tipoLimpeza));
            context.Artigos.Add(new Artigo("Lixívia Tradicional", tipoLimpeza));
            context.Artigos.Add(new Artigo("Desengordurante", tipoLimpeza));
            context.Artigos.Add(new Artigo("Limpa-Vidros", tipoLimpeza));
            context.Artigos.Add(new Artigo("Sacos do Lixo 30L", tipoLimpeza));
            context.Artigos.Add(new Artigo("Esponjas de Loiça", tipoLimpeza));
            context.Artigos.Add(new Artigo("Esfregona", tipoLimpeza));

            // --- HIGIENE PESSOAL ---
            context.Artigos.Add(new Artigo("Gel de Banho", tipoHigiene));
            context.Artigos.Add(new Artigo("Champô", tipoHigiene));
            context.Artigos.Add(new Artigo("Desodorizante Roll-on", tipoHigiene));
            context.Artigos.Add(new Artigo("Pasta de Dentes", tipoHigiene));
            context.Artigos.Add(new Artigo("Escova de Dentes", tipoHigiene));
            context.Artigos.Add(new Artigo("Fio Dentário", tipoHigiene));
            context.Artigos.Add(new Artigo("Sabonete Sólido", tipoHigiene));
            context.Artigos.Add(new Artigo("Papel Higiénico (12 rolos)", tipoHigiene));
            context.Artigos.Add(new Artigo("Cotonetes", tipoHigiene));
            context.Artigos.Add(new Artigo("Espuma de Barbear", tipoHigiene));

            // --- ANIMAIS ---
            context.Artigos.Add(new Artigo("Ração Seca Cão Adulto", tipoAnimais));
            context.Artigos.Add(new Artigo("Patê para Cão", tipoAnimais));
            context.Artigos.Add(new Artigo("Biscoitos para Cão", tipoAnimais));
            context.Artigos.Add(new Artigo("Areia Absorvente Gato", tipoAnimais));
            context.Artigos.Add(new Artigo("Ração Seca Gato", tipoAnimais));
            context.Artigos.Add(new Artigo("Patê para Gato", tipoAnimais));
            context.Artigos.Add(new Artigo("Comida para Pássaros", tipoAnimais));
            context.Artigos.Add(new Artigo("Feno para Roedores", tipoAnimais));
            context.Artigos.Add(new Artigo("Coleira Antiparasitária", tipoAnimais));
            context.Artigos.Add(new Artigo("Brinquedo para Mastigar", tipoAnimais));

            // --- ELETRÓNICA ---
            context.Artigos.Add(new Artigo("Pilhas Alcalinas AA (4 un)", tipoEletronica));
            context.Artigos.Add(new Artigo("Pilhas Alcalinas AAA (4 un)", tipoEletronica));
            context.Artigos.Add(new Artigo("Cabo USB-C", tipoEletronica));
            context.Artigos.Add(new Artigo("Cabo Lightning (iPhone)", tipoEletronica));
            context.Artigos.Add(new Artigo("Carregador de Parede", tipoEletronica));
            context.Artigos.Add(new Artigo("Auscultadores Bluetooth", tipoEletronica));
            context.Artigos.Add(new Artigo("Lâmpada LED E27", tipoEletronica));
            context.Artigos.Add(new Artigo("Pen Drive 64GB", tipoEletronica));
            context.Artigos.Add(new Artigo("Powerbank 10000mAh", tipoEletronica));
            context.Artigos.Add(new Artigo("Rato de Computador Sem Fios", tipoEletronica));

            // --- VESTUÁRIO ---
            context.Artigos.Add(new Artigo("T-shirt Algodão", tipoRoupa));
            context.Artigos.Add(new Artigo("Calças de Ganga", tipoRoupa));
            context.Artigos.Add(new Artigo("Casaco de Inverno", tipoRoupa));
            context.Artigos.Add(new Artigo("Camisola de Malha", tipoRoupa));
            context.Artigos.Add(new Artigo("Camisa de Manga Comprida", tipoRoupa));
            context.Artigos.Add(new Artigo("Calções de Desporto", tipoRoupa));
            context.Artigos.Add(new Artigo("Pack de Meias (3 pares)", tipoRoupa));
            context.Artigos.Add(new Artigo("Roupa Interior", tipoRoupa));
            context.Artigos.Add(new Artigo("Pijama", tipoRoupa));
            context.Artigos.Add(new Artigo("Sapatilhas Casuais", tipoRoupa));

            // 3. Criar Utilizadores (Administração e Testes)
            context.Utilizadores.Add(new Utilizador("joao.silva", "12345"));
            context.Utilizadores.Add(new Utilizador("maria.santos", "12345"));
            context.Utilizadores.Add(new Utilizador("admin", "admin"));

            // Salvar as alterações na base de dados
            base.Seed(context);

        }
    }
}
