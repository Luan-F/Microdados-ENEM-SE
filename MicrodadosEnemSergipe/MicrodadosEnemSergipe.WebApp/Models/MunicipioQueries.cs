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
			.Join(escolaridades.Where(x => x.CodigoUF == 28),
				provaAC => provaAC.NumeroInscricao,
				escolaridade => escolaridade.NumeroInscricao,
				(provaAC, escolaridade) => new {
					provaAC.NumeroInscricao,
					provaAC.NotaCH,
					provaAC.NotaCN,
					provaAC.NotaLC,
					provaAC.NotaMT,
					escolaridade.NomeMunicipio,
					PresencaDia1 = provaAC.PresencaCH ? 1 : 0,
					PresencaDia2 = provaAC.PresencaCN ? 1 : 0,
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
					j.PresencaDia1,
					j.PresencaDia2,
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
					j.PresencaDia1,
					j.PresencaDia2,
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
					PresencaDia1 = notas.Average(x => x.PresencaDia1),
					PresencaDia2 = notas.Average(x => x.PresencaDia2),
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
			NotaGeral = (x.NotaCH + x.NotaCN
					+ x.NotaLC + x.NotaMT
					+ x.NotaRedacao) / 5F,
			PresencaDia1 = (float)x.PresencaDia1 * 100,
			PresencaDia2 = (float)x.PresencaDia2 * 100,
		});
	}
}
