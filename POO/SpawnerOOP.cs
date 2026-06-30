// ACOPLAMENTO (CBO): esta classe DEPENDE diretamente de:
//   - BolinhaFisicaOOP  (GetComponent + atribuição de campo)
//   - UnityEngine.GameObject
//   - UnityEngine.MonoBehaviour (herança)

using UnityEngine;

/// <summary>
/// Responsável por instanciar e inicializar N bolinhas no início da cena.
/// </summary>
public class SpawnerOOP : MonoBehaviour
{
    // ── CONFIGURAÇÃO 
    [SerializeField] private GameObject prefabBolinha;
    [SerializeField] private int        quantidade  = 1000;
    [SerializeField] private float      areaSpawn   = 10f;
    [SerializeField] private float      alturaMin   = 5f;
    [SerializeField] private float      alturaMax   = 15f;
    [SerializeField] private float      velHorizMax = 3f;

    private void Start()
    {
        // Pré-aloca uma lista de GameObjects para reduzir realocações de heap
        for (int i = 0; i < quantidade; i++)
        {
            InstanciarBolinha();
        }
    }

    /// <summary>
    /// Instancia uma bolinha em posição e velocidade aleatórias.
    /// PONTO DE ACOPLAMENTO: Spawner acessa diretamente o componente
    /// BolinhaFisicaOOP e modifica seu campo `velocidade` — característica
    /// de acoplamento forte (CBO elevado) típica do OOP.
    /// </summary>
    private void InstanciarBolinha()
    {
        Vector3 posicaoInicial = new Vector3(
            Random.Range(-areaSpawn, areaSpawn),
            Random.Range(alturaMin,  alturaMax),
            Random.Range(-areaSpawn, areaSpawn)
        );

        // Instanciação do Unity: cria GameObject + todos os seus Components
        GameObject go = Instantiate(prefabBolinha, posicaoInicial, Quaternion.identity);

        // Acoplamento direto
        BolinhaFisicaOOP bolinha = go.GetComponent<BolinhaFisicaOOP>();
        if (bolinha != null)
        {
            bolinha.velocidade = new Vector3(
                Random.Range(-velHorizMax, velHorizMax),
                0f,
                Random.Range(-velHorizMax, velHorizMax)
            );
        }
    }
}
