using MicrodadosEnemSergipe.WebApp.Data;
public class MunicipioQueries : AbstractQueryClass {
	public MunicipioQueries(ContextConnection context)
	{
		provasAreaConhecimento = context.provaareaconhecimento.AsQueryable();
		redacoes = context.redacao.AsQueryable();
		escolaridades = context.escolaridade.AsQueryable();
		mediaMunicipios = this.ExecuteJoin();
	}

	public IQueryable<MediaMunicipio> ExecuteJoin()
	{
		if (redacoes == null || provasAreaConhecimento == null || escolaridades == null) {
			throw new Exception("A classe apresenta algum campo relevante nulo");
		}

		var join = provasAreaConhecimento
			.Join(escolaridades,
				provaAC => provaAC.NumeroInscricao,
				escolaridade => escolaridade.NumeroInscricao,
				(provaAC, escolaridade) => new {
					provaAC.NumeroInscricao,
					provaAC.NotaCH,
					provaAC.NotaCN,
					provaAC.NotaLC,
					provaAC.NotaMT,
					escolaridade.NomeMunicipio,
			})
			.Join(redacoes,
				j => j.NumeroInscricao,
				redacao => redacao.NumeroInscricao,
				(j, redacao) => new {
					j.NomeMunicipio,
					j.NotaCH,
					j.NotaCN,
					j.NotaLC,
					j.NotaMT,
					redacao.NotaComp1,
					redacao.NotaComp2,
					redacao.NotaComp3,
					redacao.NotaComp4,
					redacao.NotaComp5,
					redacao.NotaRedacao,
				})
			.GroupBy(j => j.NomeMunicipio,
				j => new {
					j.NotaCH,
					j.NotaCN,
					j.NotaLC,
					j.NotaMT,
					j.NotaComp1,
					j.NotaComp2,
					j.NotaComp3,
					j.NotaComp4,
					j.NotaComp5,
					j.NotaRedacao,
				},
				(Municipio, notas) => new {
					Municipio,
					NotaCH = notas.Average(x => x.NotaCH),
					NotaCN = notas.Average(x => x.NotaCN),
					NotaLC = notas.Average(x => x.NotaLC),
					NotaMT = notas.Average(x => x.NotaMT),
					NotaComp1 = notas.Average(x => x.NotaComp1),
					NotaComp2 = notas.Average(x => x.NotaComp2),
					NotaComp3 = notas.Average(x => x.NotaComp3),
					NotaComp4 = notas.Average(x => x.NotaComp4),
					NotaComp5 = notas.Average(x => x.NotaComp5),
					NotaRedacao = notas.Average(x => x.NotaRedacao),
					PresencaDia1 = Municipio == "Aracaju" ? 100F : 42F,
					PresencaDia2 = Municipio == "Aracaju" ? 100F : 42F,
				});

		return join.Select(x => new MediaMunicipio {
			NomeMunicipio = x.Municipio,
			NotaCH = x.NotaCH,
			NotaCN = x.NotaCN,
			NotaLC = x.NotaLC,
			NotaMT = x.NotaMT,
			NotaComp1 = x.NotaComp1,
			NotaComp2 = x.NotaComp2,
			NotaComp3 = x.NotaComp3,
			NotaComp4 = x.NotaComp4,
			NotaComp5 = x.NotaComp5,
			NotaRedacao = x.NotaRedacao,
			NotaGeral = (x.NotaCH + x.NotaLC + x.NotaRedacao
					+ x.NotaCN + x.NotaMT) / 5,
			PresencaDia1 = x.PresencaDia1,
			PresencaDia2 = x.PresencaDia2,
		});
	}
}
